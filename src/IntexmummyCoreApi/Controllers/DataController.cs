using Microsoft.AspNetCore.Mvc;
namespace IntexmummyCoreApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IntexmummyCoreApi.Data;
using System.Numerics;
using System.Diagnostics;

[ApiController]
[Route("[controller]")]
public class DataController : ControllerBase
{
    private MummyDbContext _context;

    public DataController(MummyDbContext context)
    {
        _context = context;
    }


    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<Mummy>>> GetBurialMains()
    {
        return await _context.Joined_main.ToListAsync();
    }

    [HttpPost("create")]
    public async Task<ActionResult<IEnumerable<Mummy>>> NewBurial(Mummy newBurial)
    {
        var burial = new Mummy
        {
            squarenorthsouth = newBurial.squarenorthsouth,
            headdirection = newBurial.headdirection,
            sex = newBurial.sex,
            northsouth = newBurial.northsouth,
            depth = newBurial.depth,
            eastwest = newBurial.eastwest,
            adultsubadult = newBurial.adultsubadult,
            facebundles = newBurial.facebundles,
            southtohead = newBurial.southtohead,
            preservation = newBurial.preservation,
            fieldbookpage = newBurial.fieldbookpage,
            squareeastwest = newBurial.squareeastwest,
            goods = newBurial.goods,
            text = newBurial.text,
            wrapping = newBurial.wrapping,
            haircolor = newBurial.haircolor,
            westtohead = newBurial.westtohead,
            samplescollected = newBurial.samplescollected,
            area = newBurial.area,
            burialid_x = newBurial.burialid_x,
            length = newBurial.length,
            burialnumber_x = newBurial.burialnumber_x,
            dataexpertinitials = newBurial.dataexpertinitials,
            westtofeet = newBurial.westtofeet,
            ageatdeath = newBurial.ageatdeath,
            southtofeet = newBurial.southtofeet,
            excavationrecorder = newBurial.excavationrecorder,
            photos = newBurial.photos,
            hair = newBurial.hair,
            burialmaterials = newBurial.burialmaterials,
            dateofexcavation = DateTime.SpecifyKind((DateTime)newBurial.dateofexcavation, DateTimeKind.Utc),
            fieldbookexcavationyear = newBurial.fieldbookexcavationyear,
            clusternumber = newBurial.clusternumber,
            shaftnumber = newBurial.shaftnumber,
        };

        _context.Joined_main.Add(burial);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(newBurial), new { id = burial.id }, burial);
    }

    public class DeleteRequest
    {
        public long id { get; set; }
    }

    [HttpPost("delete")]
    public async Task<ActionResult> DeleteBurial([FromBody] DeleteRequest request)
    {
        // Retrieve the record from the database
        var burial = await _context.Joined_main.FindAsync(request.id);
        Debug.WriteLine("burial: " + burial);

        if (burial == null)
        {
            return NotFound();
        }

        // Remove the record from the database
        _context.Joined_main.Remove(burial);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateBurial([FromBody] Mummy updatedBurial)
    {
        var existingBurial = await _context.Joined_main.FindAsync(updatedBurial.id);
        if (existingBurial == null)
        {
            return NotFound();
        }

        existingBurial.squarenorthsouth = updatedBurial.squarenorthsouth;
        existingBurial.headdirection = updatedBurial.headdirection;
        existingBurial.sex = updatedBurial.sex;
        existingBurial.northsouth = updatedBurial.northsouth;
        existingBurial.depth = updatedBurial.depth;
        existingBurial.eastwest = updatedBurial.eastwest;
        existingBurial.adultsubadult = updatedBurial.adultsubadult;
        existingBurial.facebundles = updatedBurial.facebundles;
        existingBurial.southtohead = updatedBurial.southtohead;
        existingBurial.preservation = updatedBurial.preservation;
        existingBurial.fieldbookpage = updatedBurial.fieldbookpage;
        existingBurial.squareeastwest = updatedBurial.squareeastwest;
        existingBurial.goods = updatedBurial.goods;
        existingBurial.text = updatedBurial.text;
        existingBurial.wrapping = updatedBurial.wrapping;
        existingBurial.haircolor = updatedBurial.haircolor;
        existingBurial.westtohead = updatedBurial.westtohead;
        existingBurial.samplescollected = updatedBurial.samplescollected;
        existingBurial.area = updatedBurial.area;
        existingBurial.burialid_x = updatedBurial.burialid_x;
        existingBurial.length = updatedBurial.length;
        existingBurial.burialnumber_x = updatedBurial.burialnumber_x;
        existingBurial.dataexpertinitials = updatedBurial.dataexpertinitials;
        existingBurial.westtofeet = updatedBurial.westtofeet;
        existingBurial.ageatdeath = updatedBurial.ageatdeath;
        existingBurial.southtofeet = updatedBurial.southtofeet;
        existingBurial.excavationrecorder = updatedBurial.excavationrecorder;
        existingBurial.photos = updatedBurial.photos;
        existingBurial.hair = updatedBurial.hair;
        existingBurial.burialmaterials = updatedBurial.burialmaterials;
        existingBurial.dateofexcavation = DateTime.SpecifyKind((DateTime)updatedBurial.dateofexcavation, DateTimeKind.Utc);
        existingBurial.fieldbookexcavationyear = updatedBurial.fieldbookexcavationyear;
        existingBurial.clusternumber = updatedBurial.clusternumber;
        existingBurial.shaftnumber = updatedBurial.shaftnumber;

        _context.Joined_main.Update(existingBurial);
        await _context.SaveChangesAsync();

        return Ok(existingBurial);
    }










}

